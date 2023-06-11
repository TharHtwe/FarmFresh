using FarmFresh_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System;
using FarmFresh_API.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using FarmFresh_API.Helpers;

namespace FarmFresh_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        [Authorize(Policy = "Admin")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileList = new List<string>();

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var oriFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileName = Guid.NewGuid().ToString() + oriFileName.Substring(oriFileName.LastIndexOf('.'));
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    fileList.Add(dbPath);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok(new { Message = "All the files are successfully uploaded.", List = fileList });
            }
            catch (Exception ex)
            {
                Logger.LogWrite(ex.Message + "\n" + ex.StackTrace);
                return StatusCode(500, "Internal server error");
            }
        }

        //[Authorize(Policy = "Admin")]
        //[HttpPost, DisableRequestSizeLimit]
        //public async Task<IActionResult> UploadSingle()
        //{
        //    try
        //    {
        //        var formCollection = await Request.ReadFormAsync();
        //        var file = formCollection.Files.First();
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fileName = Guid.NewGuid().ToString();
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}
    }
}
