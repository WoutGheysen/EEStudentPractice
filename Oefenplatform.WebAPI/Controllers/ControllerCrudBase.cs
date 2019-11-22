using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.DTO;
using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Repositories.Base;

namespace Oefenplatform.WebAPI.Controllers
{
        public class ControllerCrudBase<T, R> : ControllerBase
        where T : EntityBase<int>
        where R : RepositoryBase<T>
        {
            protected R _repository;

            public ControllerCrudBase(R repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public virtual async Task<IActionResult> Get()
            {
                return Ok(await _repository.ListAll());
            }

            [HttpGet("{id}")]
            public virtual async Task<IActionResult> Get(int id)
            {
                return Ok(await _repository.GetById(id));
            }

            [HttpPut("{id}")]
            public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] T entity)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != entity.Id)
                {
                    return BadRequest();
                }

                T updatedEntity = await _repository.Update(entity);
                if (updatedEntity == null)
                {
                    return NotFound();
                }
                return Ok(updatedEntity);
            }

            [HttpPost]
            public virtual async Task<IActionResult> Post([FromBody] T entity)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                T createdEntity = await _repository.Add(entity);
                if (createdEntity == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
            }

            [HttpDelete("{id}")]
            public virtual async Task<IActionResult> Delete([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                T deletedEntity = await _repository.Delete(id);
                if (deletedEntity == null)
                {
                    return NotFound();
                }
                return Ok(deletedEntity);
            }
        }
}
