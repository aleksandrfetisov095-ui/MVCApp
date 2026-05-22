using ex2.Models;
namespace ex2.Repositories

{
    public class TextbookRepository
    {
        private List<Textbook> _textbooks;

        public TextbookRepository()
        {
            _textbooks = new List<Textbook>
        {
            new()
            {
                Id = 1,
                Title = "Курс высшей математики",
                Subject = "Высшая математика",
                Author = "Гусак А.А.",
                Year = 2019,
                Pages = 544,
                Price = 1200,
                Description = "Полный курс высшей математики для технических вузов. Включает линейную алгебру, аналитическую геометрию, математический анализ, дифференциальные уравнения.",
                CoverUrl = "https://bhv.ru/wp-content/uploads/2019/12/1081_978-5-94157-909-9.jpg"
            },
            new()
            {
                Id = 2,
                Title = "Курс общей физики",
                Subject = "Физика",
                Author = "Савельев И.В.",
                Year = 2020,
                Pages = 560,
                Price = 1500,
                Description = "Учебник охватывает все разделы общего курса физики: механика, молекулярная физика, электродинамика, оптика, квантовая физика.",
                CoverUrl = "https://e.lanbook.com/img/cover/book/142380.jpg"
            },
            new()
            {
                Id = 3,
                Title = "История России с древнейших времён",
                Subject = "История России",
                Author = "Орлов А.С.",
                Year = 2021,
                Pages = 592,
                Price = 980,
                Description = "Учебник охватывает весь курс истории России от Древней Руси до современной Российской Федерации.",
                CoverUrl = "https://www.hist.msu.ru/upload/medialibrary/9a4/04679FCE-0E3D-49DB-9CDC-476F79A7ABC1.png"
            },
            new()
            {
                Id = 4,
                Title = "Практический курс английского языка",
                Subject = "Английский язык",
                Author = "Голицинский Ю.Б.",
                Year = 2018,
                Pages = 736,
                Price = 850,
                Description = "Комплексный учебник по английскому языку. Включает грамматику, лексику, упражнения на чтение, письмо, аудирование и говорение.",
                CoverUrl = "https://www.moscowbooks.ru/image/book/803/w259/i803458.jpg?cu=20240131174507"
            }
        };
        }

        public List<Textbook> Get()
        {
            return _textbooks;
        }

        public Textbook GetById(int id)
        {
            return _textbooks.First(x => x.Id == id);
        }
    }
}
