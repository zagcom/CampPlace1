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

namespace CampplaceTest1.Controllers
{
    public class CampsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileProvider fileProvider;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public CampsController(ApplicationDbContext context, IFileProvider fileprovider, IHostingEnvironment env, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            fileProvider = fileprovider;
            hostingEnvironment = env;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Camps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Camp.ToListAsync());
        }

        // GET: Camps/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Camps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Voivodeship,Community,Name,Description,Coordinates,Address,SummerCamp,WinterCamp,Bivouac,Scouts,WolfCubs,Buildings,Toilet,Kitchen,SleepingInside,MaxPeopleCapacity,DistanceFromBuildings,NearestHospital,NearestFireDepartment,NearestPoliceStation,NearestMarket,ContactPoint,EmailToCP,PhoneToCP")] Camp camp, IFormFile file)
        {
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if (ModelState.IsValid)
            {
                _context.Add(camp);
                await _context.SaveChangesAsync();
                
                
                if (file != null || file.Length != 0)
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
                    camp.LastEdited = DateTime.Now;
                    camp.ImagePath = pathToSave;
                    camp.OwnerId = userId;
                    _context.Update(camp);
                    await _context.SaveChangesAsync();

                    
                }


                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }

        // GET: Camps/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voivodeship,Community,Name,Description,Coordinates,Address,SummerCamp,WinterCamp,Bivouac,Scouts,WolfCubs,Buildings,Toilet,Kitchen,SleepingInside,MaxPeopleCapacity,ImagePath,DistanceFromBuildings,NearestHospital,NearestFireDepartment,NearestPoliceStation,NearestMarket,ContactPoint,EmailToCP,PhoneToCP,LastEdited,EditorId,OwnerId")] Camp camp)
        {
            if (id != camp.Id)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }

        // GET: Camps/Delete/5
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
