﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurantsController(OdeToFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurant;
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _context.Restaurant.FindAsync(id); //FindAsync is automatic 

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant([FromRoute] int id, [FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        [HttpPost] //You can't define the ID because the database handles that!
        public async Task<IActionResult> PostRestaurant([FromBody] Restaurant restaurant) //From Body important!
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurant.Add(restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant); //You cant return Ok, Http rule
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _context.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();

            return Ok(restaurant);
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurant.Any(e => e.Id == id);
        }
    }
}