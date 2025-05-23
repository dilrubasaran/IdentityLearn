﻿using System.ComponentModel.DataAnnotations;
using identity_signup.Areas.Instructor.Models;

namespace identity_signup.Areas.Instructor.ViewModels
{
    public class EduCreateViewModel
    {
        [Required(ErrorMessage = "Eğitim adı zorunludur.")]
        [RegularExpression(@".*\b(Kursu|Programı|Eğitimi|Okulu)\b.*", ErrorMessage = "Eğitim adında 'Kursu', 'Programı', 'Eğitimi' veya 'Okulu' kelimelerinden biri yer almalıdır.")]

        [Display(Name = "Eğitim Adı")]
        public string EduName { get; set; }

        [Display(Name = "Eğitimci Adı")]
        public string CreatedBy {get; set;}

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Eğitim tipi zorunludur.")]
        [Display(Name = "Eğitim Tipi")]
        public EduType EduType { get; set; }

        [Required(ErrorMessage = "Eğitim süresi zorunludur.")]
        [RegularExpression(@".*\b(Saat|Hafta)\b.*", ErrorMessage = "Geçerli bir eğitim süresi girin. Örn: '2 Saat' veya '4 Hafta'")]

        public string EduDuration { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        [Display(Name = "Fiyat")]
        public decimal EduPrice { get; set; }
    }
}
