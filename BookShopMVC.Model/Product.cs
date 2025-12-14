using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShopMVC.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? ISBN { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        [Display(Name = "Giá từ 1 - 50")]
        [Range(1, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Giá từ 50+")]
        [Range(1, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Price50 { get; set; }

        [Required]
        [Display(Name = "Giá từ 100+")]
        [Range(1, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Price100 { get; set; }

        public int? CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Gắn hình mặc định dựa trên Id sản phẩm
        [ValidateNever]
        public string ImageUrl
        {
            get
            {
                return Id switch
                {
                    1 => "/images/z6321261835893_7d33517c242d4a19d080e5eb5462219.jpg",
                    2 => "/images/7841a8aa-5238-4936-a3fa-d4cd2e5b2da4.jpg",
                    3 => "/images/m142341251_4m124n512515bh3125h123jhb11251v5125v1.jpg",
                    4 => "/images/c7bb7509-1d22-42c8-830b-72ef72d702a6.jpg",
                    5 => "/images/e6f61eee-5404-48bc-9aa7-6f26d50288ea.jpg",
                    6 => "/images/703d095a-25d8-4eeb-bb71-82f20add7270.jpg",
                    _ => "/images/default.jpg"
                };
            }
            set { /* Có thể override nếu muốn */ }
        }

        [Display(Name = "Mới")]
        public bool IsNew { get; set; }

        [Display(Name = "Bán chạy")]
        public bool IsBestseller { get; set; }

        [Display(Name = "Ưu đãi đặc biệt")]
        public bool IsSpecialOffer { get; set; }
    }
}
