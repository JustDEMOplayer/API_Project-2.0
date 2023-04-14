using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Вывод категорий
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _categoryService.GetAll());

        /// <summary>
        /// Вывод категорий товара
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _categoryService.GetById(id));

        /// <summary>
        /// Добавление категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "id": 1,
        ///         "parentId": 2 //Опционально
        ///         "name": "Периферийные устройства",
        ///         "description": "Все периферийные устройства" //Опционально
        ///         "isDeleted": "03-31-2023 10:00:00" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="category">Категория товара</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryService.Create(category);

            return Ok();
        }

        /// <summary>
        /// Изменение категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "id": 1,
        ///         "parentId": 2 //Опционально
        ///         "name": "Компьютерные мыши",
        ///         "description": "Компьютерные мыши для ПК и ноутбуков" //Опционально
        ///         "isDeleted": "03-31-2023 10:00:00" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="category">Категория товара</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.Update(category);

            return Ok();
        }

        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);

            return Ok();
        }
    }
}
