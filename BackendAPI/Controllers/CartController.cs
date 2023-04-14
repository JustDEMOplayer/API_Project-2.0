using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService userService)
        {
            _cartService = userService;
        }

        /// <summary>
        /// Вывод корзин пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _cartService.GetAll());

        /// <summary>
        /// Вывод вещи в корзине пользователя
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <param name="goodId">id товара</param>
        /// <returns></returns>
        [HttpGet("{userId}/{goodId}")]
        public async Task<IActionResult> GetById(int userId, int goodId) => Ok(await _cartService.GetById(userId, goodId));

        /// <summary>
        /// Добавление новых вещей в корзину пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "userId": 1,
        ///         "goodId": 1,
        ///         "count": 5
        ///     }
        /// 
        /// </remarks>
        /// <param name="cart">Новая позиция</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Cart cart)
        {
            await _cartService.Create(cart);

            return Ok();
        }

        /// <summary>
        /// Обновление вещи в корзине пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "userId": 1,
        ///         "goodId": 1,
        ///         "count": 4
        ///     }
        /// 
        /// </remarks>
        /// <param name="cart">Обновлённая позиция</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Cart cart)
        {
            await _cartService.Update(cart);

            return Ok();
        }

        /// <summary>
        /// Удаляет вещь из корзины пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="goodId">Id товара</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int userId, int goodId)
        {
            await _cartService.Delete(userId, goodId);

            return Ok();
        }
    }
}
