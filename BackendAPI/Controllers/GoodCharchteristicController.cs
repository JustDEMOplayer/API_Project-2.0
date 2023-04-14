using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodCharachteristicController : ControllerBase
    {
        private IGoodCharachteristicService _userService;

        public GoodCharachteristicController(IGoodCharachteristicService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение всех характеристик товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAll());

        /// <summary>
        /// Вывод нужной характеристики товара
        /// </summary>
        /// <param name="goodId">Id товара</param>
        /// <param name="filterId">Id фильтра (характеристики)</param>
        /// <returns></returns>
        [HttpGet("{id}/{filterId}")]
        public async Task<IActionResult> GetById(int goodId, int filterId) => Ok(await _userService.GetById(goodId, filterId));

        /// <summary>
        /// Добавление новой характеристики товару
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "goodId": 1,
        ///         "filterId": 1,
        ///         "value": "да" //у данного атрибута тип sql_variant, так что можно вставлять любое значение, которое подходит для данной характеристики
        ///     }
        ///     
        /// </remarks>
        /// <param name="goodCharachteristic"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(GoodCharachteristic goodCharachteristic)
        {
            await _userService.Create(goodCharachteristic);

            return Ok();
        }

        /// <summary>
        /// Изменение характеристик товара
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "goodId": 1,
        ///         "filterId": 1,
        ///         "value": false //у данного атрибута тип sql_variant, так что можно вставлять любое значение, которое подходит для данной характеристики
        ///     }
        ///     
        /// </remarks>
        /// <param name="goodCharachteristic"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GoodCharachteristic goodCharachteristic)
        {
            await _userService.Update(goodCharachteristic);

            return Ok();
        }

        /// <summary>
        /// Удаление характеристик товара
        /// </summary>
        /// <param name="goodId">Id товара</param>
        /// <param name="filterId">Id фильтра(характеристики)</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int goodId, int filterId)
        {
            await _userService.Delete(goodId, filterId);

            return Ok();
        }
    }
}
