﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public ImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage images)
        {
            var result = _carImageService.Add(file, images);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("CarId"))] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;
            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = "Id")] int Id)
        {
            try
            {
                var carImage = _carImageService.Get(Id).Data;
                var result = _carImageService.Update(file, carImage);

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carImageService.GetAll();


            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getımagesbyıd")]
        public IActionResult GetById([FromForm(Name = "Id")] int Id)
        {
            var result = _carImageService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
      
    }

}


