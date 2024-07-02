﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Website_System_API.Models;
using Travel_Website_System_API_.Repositories;
using Travel_Website_System_API_.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;

namespace Travel_Website_System_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        GenericRepository<Package> packageRepo;
        private readonly IPackageRepo _packageRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PackagesController(GenericRepository<Package> packageRepo,IPackageRepo repo , IWebHostEnvironment webHostEnvironment)
        {
            this.packageRepo = packageRepo;
            this._packageRepo = repo;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Packages
        [HttpGet]
        public ActionResult GetPackages(int pageNumber = 1, int pageSize = 10)
        {
            List<Package> packages = packageRepo.GetAllWithPagination(pageNumber, pageSize);
            int totalPackages = packageRepo.GetTotalCount();

            List<PackageDTO> packageDTOs = new List<PackageDTO>();

            foreach (Package package in packages)
            {
                var serviceNames = package.PackageServices.Select(ps => ps.Service.Name).ToList();

                packageDTOs.Add(new PackageDTO
                {
                    Id = package.Id,
                    Name = package.Name,
                    Description = package.Description,
                    ImageUrl = package.Image,
                    QuantityAvailable = package.QuantityAvailable,
                    Price = package.Price,
                    isDeleted = package.isDeleted,
                    startDate = package.startDate,
                    Duration = package.Duration,
                    adminId = package.adminId,
                    ServiceNames = serviceNames // Include service names
                });
            }

            var response = new PaginatedResponse<PackageDTO>
            {
                TotalCount = totalPackages,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = packageDTOs
            };

            return Ok(response);
        }

        [HttpGet("Search/{searchItem}")]
        public ActionResult<List<string>> Search(string searchItem)
        {
            var serviceNames = _packageRepo.Search(searchItem);
            return Ok(serviceNames);
        }


        [HttpGet("{name:alpha}")]
        public ActionResult GetPackageByName(string name)
        {
            var package = _packageRepo.GetByName(name);

            if (package == null) return NotFound();
            else
            {
                // Ensure that related services are loaded
                var serviceNames = package.PackageServices.Select(ps => ps.Service.Name).ToList();

                PackageDTO packageDTO = new PackageDTO()
                {
                    Id = package.Id,
                    Name = package.Name,
                    Description = package.Description,
                    ImageUrl = package.Image,
                    QuantityAvailable = package.QuantityAvailable,
                    Price = package.Price,
                    isDeleted = package.isDeleted,
                    startDate = package.startDate,
                    Duration = package.Duration,
                    adminId = package.adminId,
                    ServiceNames = serviceNames // Include service names

                };
                return Ok(packageDTO);
            }
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public ActionResult GetPackageById(int id)
        {
            var package = packageRepo.GetById(id);

            if (package == null) return NotFound();
            else
            {
                // Ensure that related services are loaded
                var serviceNames = package.PackageServices.Select(ps => ps.Service.Name).ToList();

                PackageDTO packageDTO = new PackageDTO() {
                    Id = package.Id,
                    Name = package.Name,
                    Description = package.Description,
                    ImageUrl = package.Image,
                    QuantityAvailable = package.QuantityAvailable,
                    Price = package.Price,
                    isDeleted = package.isDeleted,
                    startDate = package.startDate,
                    Duration = package.Duration,
                    adminId = package.adminId,
                    ServiceNames = serviceNames // Include service names

                };
                return Ok(packageDTO);
            }
        }


        // POST: api/Packages
       // [Authorize(Roles = "superAdmin, admin")]
        [HttpPost]
        public ActionResult AddPackage(PackageDTO packageDTO)
        {
            if (packageDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            string uniqueFileName = UploadImage(packageDTO.Image);

            Package package = new Package() {
                //Id = packageDTO.Id,
                Name = packageDTO.Name,
                Description = packageDTO.Description,
                Image = uniqueFileName,
                QuantityAvailable = packageDTO.QuantityAvailable,
                Price = packageDTO.Price,
                isDeleted = packageDTO.isDeleted,
                startDate = packageDTO.startDate,
                Duration = packageDTO.Duration,
                adminId = packageDTO.adminId
            };
            packageRepo.Add(package);
            packageRepo.Save();
            // return Ok(packageDTO);
            return CreatedAtAction("GetPackageById", new { id = package.Id }, packageDTO);

        }


        //implement image any problem call helmy 
        private string UploadImage(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {

                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/packages");


                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique filename for the uploaded file
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Combine the uploads folder path with the unique filename
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the file to the specified path
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Return the unique filename
                return uniqueFileName;
            }

            // If file is null or has no content, return null
            return null;
        }



        // PUT: api/Packages/5
        [Authorize(Roles = "superAdmin, admin")]
        [HttpPut("{id}")]
        public ActionResult EditPackage(int id, PackageDTO packageDTO)
        {
           // var userId=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userId !=packageDTO.adminId) return BadRequest("this admin can not update this Package");
            if (packageDTO == null) return BadRequest();
            if (packageDTO.Id != id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            string uniqueFileName = UploadImage(packageDTO.Image);
            Package package = new Package()
            {
                Id = packageDTO.Id,
                Name = packageDTO.Name,
                Description = packageDTO.Description,
                Image = uniqueFileName,
                QuantityAvailable = packageDTO.QuantityAvailable,
                Price = packageDTO.Price,
                isDeleted = packageDTO.isDeleted,
                startDate = packageDTO.startDate,
                Duration = packageDTO.Duration,
                adminId = packageDTO.adminId
            };
            packageRepo.Edit(package);
            packageRepo.Save();
            return NoContent();
        }


        // DELETE: api/Packages/5
        //[Authorize(Roles = "superAdmin, admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletePackage(int id)
        {
            Package package = packageRepo.GetById(id);
            if (package == null) return NotFound();

            if (package.QuantityAvailable == 0)
            {
                package.isDeleted = true;
                packageRepo.Edit(package); 
            }
            else
            {
                packageRepo.Remove(package);
            }

            packageRepo.Save();
            return Ok(package);
        }


    }
}
