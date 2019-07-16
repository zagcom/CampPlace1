using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampplaceTest1.Data;
using CampplaceTest1.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CampplaceTest1.Controllers
{
    public class CampsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileProvider fileProvider;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public CampsController(ApplicationDbContext context, IFileProvider fileprovider, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            fileProvider = fileprovider;
            hostingEnvironment = env;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Camps
        [Authorize(Roles = "MasterUser,Member")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Camp.ToListAsync());
        }

        // GET: Camps/Details/5
        
        [Authorize(Roles = "MasterUser,CanViewAndCreateCamps")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp.FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // GET: Camps/Create
        [Authorize(Roles = "MasterUser,CanViewAndCreateCamps")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "MasterUser,CanViewAndCreateCamps")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Voivodeship,Community,Name,Description,Coordinates,Address,SummerCamp,WinterCamp,Bivouac,Scouts,WolfCubs,Buildings,Toilet,Shower,Kitchen,SleepingInside,MaxPeopleCapacity,DistanceFromBuildings,NearestHospital,NearestFireDepartment,NearestPoliceStation,NearestMarket,NearestParish,Sanel,Superintendance,PoviatFireBrigade,EvacuationPlace,EvacuationDistance,ContactPoint,EmailToCP,PhoneToCP,AccessibleByCar")] Camp camp, IFormFile file)
        {
            var user = await GetCurrentUserAsync();
            var userName = user?.FirstName + " " + user?.LastName;
            var userId = user?.Id;
            if (ModelState.IsValid)
            {
                camp.TimeCreated = DateTime.Now;
                camp.OwnerName = userName;
                camp.OwnerId = userId;
                camp.ImagePath = @"/images/placeholder-image.jpg";
                _context.Add(camp);
                await _context.SaveChangesAsync();
                
                
                if (file != null)
                {
                    // Create a File Info 
                    FileInfo fi = new FileInfo(file.FileName);

                    // This code creates a unique file name to prevent duplications 
                    // stored at the file location
                    var newFilename = camp.Id + "_" + String.Format("{0:d}",
                                      (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\images\" + newFilename);

                    // IMPORTANT: The pathToSave variable will be save on the column in the database
                    var pathToSave = @"/images/" + newFilename;

                    // This stream the physical file to the allocate wwwroot/ImageFiles folder
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // This save the path to the record

                    camp.ImagePath = pathToSave;
                    _context.Update(camp);
                    await _context.SaveChangesAsync();


                }
                
               
                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }
        
        // GET: Camps/Edit/5
        [Authorize(Roles = "MasterUser,CanManageCamps")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp.FindAsync(id);
            if (camp == null)
            {
                return NotFound();
            }
            return View(camp);
        }

        // POST: Camps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "MasterUser,CanManageCamps")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voivodeship,Community,Name,Description,Coordinates,Address,SummerCamp,WinterCamp,Bivouac,Scouts,WolfCubs,Buildings,Toilet,Shower,Kitchen,SleepingInside,MaxPeopleCapacity,DistanceFromBuildings,NearestHospital,NearestFireDepartment,NearestPoliceStation,NearestMarket,NearestParish,Sanel,Superintendance,PoviatFireBrigade,EvacuationPlace,EvacuationDistance,ContactPoint,EmailToCP,PhoneToCP,OwnerName,TimeCreated,ImagePath,OwnerId,AccessibleByCar")] Camp camp, IFormFile file)
        {
            if (id != camp.Id)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var userName = user?.FirstName + " " + user?.LastName;
            camp.LastEdited = DateTime.Now;
            camp.EditorName = userName;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampExists(camp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (file != null)
                {
                    // Create a File Info 
                    FileInfo fi = new FileInfo(file.FileName);

                    // This code creates a unique file name to prevent duplications 
                    // stored at the file location
                    var newFilename = camp.Id + "_" + String.Format("{0:d}",
                                      (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\images\" + newFilename);

                    // IMPORTANT: The pathToSave variable will be save on the column in the database
                    var pathToSave = @"/images/" + newFilename;

                    // This stream the physical file to the allocate wwwroot/ImageFiles folder
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // This save the path to the record
                    camp.ImagePath = pathToSave;
                    _context.Update(camp);
                    await _context.SaveChangesAsync();


                }

                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }

        // GET: Camps/Delete/5
        [Authorize(Roles = "MasterUser,CanManageCamps")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // POST: Camps/Delete/5
        [Authorize(Roles = "MasterUser,CanManageCamps")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camp = await _context.Camp.FindAsync(id);
            _context.Camp.Remove(camp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampExists(int id)
        {
            return _context.Camp.Any(e => e.Id == id);
        }
    }
}
