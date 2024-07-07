﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PayPalCheckoutSdk.Orders;
using Travel_Website_System_API.Models;
using Travel_Website_System_API_.DTO;
using Travel_Website_System_API_.UnitWork;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Travel_Website_System_API_.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingPackageController : ControllerBase
    {
        UnitOFWork unitOFWork;
        public BookingPackageController(UnitOFWork unitOFWork)
        {
            this.unitOFWork = unitOFWork;
        }
      
       
        [HttpPost]
        [Consumes("application/json")]
        //[Authorize(Roles = "client")]
        public ActionResult Add(BookingPackageDTO bookingPackageDTO ) {// get client id , package id , 
            if(ModelState.IsValid)
            {
                // to check the client has booked this package before or not
                var model = unitOFWork.BookingPackageRepo.GetAll()
                    .FirstOrDefault(p=>p.clientId==bookingPackageDTO.clientId&& p.packageId==bookingPackageDTO.packageId);
                if(model!=null)//if exists
                {
                  return BadRequest(new { message = "This client has already booked this package." });
                }
                var package = unitOFWork.db.Packages.SingleOrDefault(p => p.Id == bookingPackageDTO.packageId);
                if(package.QuantityAvailable == 0)
                {
                    package.isDeleted = true;// package will be not in website and you cant booking it
                    return BadRequest(new { message = "Package not available now." });
                }
                bookingPackageDTO.Date = DateTime.Now;
                // bookingPackageDTO.allowingTime = DateTime.Now.AddDays(20);
                bookingPackageDTO.allowingTime = DateTime.Now.AddDays(package.BookingTimeAllowed ??0);
                bookingPackageDTO.price = package?.Price ?? 0;
                bookingPackageDTO.PackageImage = package?.Image ?? " ";
                //  count the number of bookings for the specified package
                var bookingCountForPackage = unitOFWork.db.BookingPackages.Count(bp => bp.packageId == bookingPackageDTO.packageId);
                bookingPackageDTO.quantity = bookingCountForPackage + 1;
                var bookingPackage = new BookingPackage
                {
                    //Id = bookingPackageDTO.BookingPackageId,// is identity
                    clientId = bookingPackageDTO.clientId,
                    quantity = bookingPackageDTO.quantity,
                    Date = bookingPackageDTO.Date,
                    allowingTime = bookingPackageDTO.allowingTime,
                    packageId = bookingPackageDTO.packageId,
                };
                unitOFWork.BookingPackageRepo.Add(bookingPackage);
                unitOFWork.Save();
                // after adding new booking for the specific package the availablequantity in package table will decreased by 1
                package.QuantityAvailable--;
                unitOFWork.db.Packages.Update(package);
                unitOFWork.Save();
                // Return the DTO with the new booking ID
                bookingPackageDTO.Id = bookingPackage.Id;

                // Populate DTO from saved entity to ensure passing all values to Dto attributes
                var savedBooking = unitOFWork.CustombookingPackageRepo.GetById(bookingPackage.Id);
                bookingPackageDTO = new BookingPackageDTO
                {
                    Id = savedBooking.Id,
                    Date = savedBooking.Date,
                    quantity = savedBooking.quantity,
                    clientId = savedBooking.clientId,
                    packageId = savedBooking.packageId,
                    allowingTime = savedBooking.allowingTime,
                    price = package.Price ?? 0,
                    PackageImage = package.Image ?? " "
                };
                // will return object in response where i can get it id in ui to pass it in payment
                return CreatedAtAction(nameof(GetBookingPackageById), new {id = bookingPackage.Id }, bookingPackageDTO);
                // i returned bookingPackage not dto as when i returned dto the booking id was =0 and not changed 
            }
            else
            {
                return BadRequest(new { message = "Invalid data provided.", errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });

            }

        }
        
        [HttpGet("{id}")]
        public IActionResult GetBookingPackageById(int id)
        {
            // here i get relative data with eager Loading
            var bookingPackage = unitOFWork.CustombookingPackageRepo.GetById(id);// to get relative data 
            if(bookingPackage == null) { return NotFound(); }
            // var clientName = bookingPackage.client?.user?.Fname ?? "Unknown";
            var bookingPackageDTO = new BookingPackageDTO
            {
                Id = bookingPackage.Id,
                Date = bookingPackage.Date,
                quantity = bookingPackage.quantity,
                clientId = bookingPackage.clientId,
                packageId = bookingPackage.packageId,
                allowingTime = bookingPackage.allowingTime,
                // clientName = clientName,// i get it for testing only i dont need it now
                price = bookingPackage.package?.Price ?? 0,
                PackageImage = bookingPackage.package?.Image ?? " "
            };
            return Ok(bookingPackageDTO);
        }

        // Route for getting all bookings for a  logined client that have no payments
        [HttpGet("client/{clientId}")]
        public IActionResult GetAllBookingForClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                return NotFound("Client ID cannot be null or empty.");
            }

            var allClientBookings = unitOFWork.CustombookingPackageRepo.SelectAllBookingforClient(clientId);

            if (allClientBookings == null || !allClientBookings.Any())
            {
                return NotFound("There are no package bookings for this client.");
            }
            var allClientBookingsDTO = new List<BookingPackageDTO>();
            foreach (var item in allClientBookings)
            {
                allClientBookingsDTO.Add(
                new BookingPackageDTO
                {
                    Id = item.Id,
                    clientId = item.clientId,
                    packageId = item.packageId,
                    allowingTime = item.allowingTime,
                    Date = item.Date,
                    quantity = item.quantity,
                    price = item.package?.Price ?? 0,
                });
            }
                
            return Ok(allClientBookingsDTO);        
            // i can return list of dto
        }
        // [Authorize(Roles ="admin,superAdmin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var bookingPackage = unitOFWork.BookingPackageRepo.GetById(id);
            if (bookingPackage == null)
            {
                return NotFound();
            }
            //bookingPackage.allowingTime < DateTime.Now: if the date of today is > date of allowingtime
            if (bookingPackage.allowingTime != null && bookingPackage.allowingTime < DateTime.Now)//package start date
            {
                // get the current package in booking row
                var package = unitOFWork.db.Packages.SingleOrDefault(s => s.Id == bookingPackage.packageId);
                package.QuantityAvailable++;
                unitOFWork.db.Packages.Update(package);// PackageRepo.update(service)
                bookingPackage.quantity--;
                unitOFWork.BookingPackageRepo.Delete(bookingPackage.Id);
                unitOFWork.Save();
                return Ok("removed");
            }
            else
            {
                // Allow booking removal only if allowing time has expired
                return BadRequest("Booking package cannot be removed as allowing time has not expired yet.");
            }
        }

        //[Authorize(Roles ="admin,superAdmin")]
        [HttpGet("AllBookings")]
        public IActionResult GetAllPackageBooking() // Get all booking for all clients
        {
            var allPackageBooking = unitOFWork.CustombookingPackageRepo.selectAll();
            if(allPackageBooking == null) { return NotFound("there are no Bookings"); }
            var AllBookingsDTO = new List<BookingPackageDTO>();
            foreach (var item in allPackageBooking)
            {
                AllBookingsDTO.Add(
                    new BookingPackageDTO
                    {
                        Id = item.Id,
                        clientId = item.clientId,
                        packageId = item.packageId,
                        allowingTime = item.allowingTime,
                        Date = item.Date,
                        quantity = item.quantity,
                        price = item.package?.Price ?? 0,
                        PackageImage = item.package.Image,
                    });   
            }

            return Ok(AllBookingsDTO);
        }
        // allBookings for a sepecific client
       // [Authorize(Roles ="client,admin,superAdmin")]
        [HttpGet("AllBookings/{clientId}")]
        public IActionResult GetAllPaidBookingsForClient(string clientId) {

            if (string.IsNullOrEmpty(clientId))
            {
                return NotFound("Client ID cannot be null or empty.");
            }
            var AllPaidBookings = unitOFWork.CustombookingPackageRepo.GetAllPaidBookingsForClient(clientId);
            var AllPaidBookingsDTO = new List<BookingPackageDTO>();

            foreach (var item in AllPaidBookings)
            {
                AllPaidBookingsDTO.Add(
                    new BookingPackageDTO
                    {
                        Id = item.Id,
                        clientId = item.clientId,
                        packageId = item.packageId,
                        allowingTime = item.allowingTime,
                        Date = item.Date,
                        quantity = item.quantity,
                        price = item.package?.Price ?? 0,
                        PackageImage = item.package.Image,
                    });
            }
            return Ok(AllPaidBookingsDTO);
        }
        
    }
}
