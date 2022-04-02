using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConApp.HeliBao
{
    public static class ValidationExtension
    {
        /// <summary>
        /// 验证为正数
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="input">带引用类型结构之外的值类型</param>
        /// <returns></returns>
        public static ValidationResult PositiveNumber<T> (T input) where T : unmanaged
        {
            var result = new ValidationResult("不是有效数字");
            if (int.TryParse(input.ToString(), out int val) && val > 0)
            {
                return ValidationResult.Success;
            }
            return result;
        }
    }
}
