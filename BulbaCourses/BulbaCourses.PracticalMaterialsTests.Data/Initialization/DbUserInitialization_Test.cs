using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using System.Collections.Generic;
using System.Data.Entity;
using BulbaCourses.PracticalMaterialsTests.Data.Models.User;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Initialization
{
    public class DbUserInitialization_Test : DropCreateDatabaseAlways<DbContext_LocalDb_Test>
    {
        protected override void Seed(DbContext_LocalDb_Test context)
        {
            MUser_TestAuthorDb User_TestAuthor =
                new MUser_TestAuthorDb() { Id = "5012f850-9c59-4fd9-9e50-4d93ecac03fb" };

            // ------------ TestData

            List<MTest_MainInfoDb> default_Test_MainInfoDb =
                 new List<MTest_MainInfoDb>()
                 {
                    new MTest_MainInfoDb()
                    {
                        Name = "Тест по C#. Начальный уровень",
                        Description = "Тест, предназначеннны для общего понимания своего текущего уровня знаний по C#",
                        DateCreate = DateTime.Now,
                        Questions_ChoosingAnswerFromList =
                            new List<MQuestion_ChoosingAnswerFromListDb>()
                            {
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Когда вызывают статический конструктор классов в С# ?",
                                     Description = "Дело в том, что бывают статические конструкторы явные (когда конструктор задан явно) и неявные (присваивание значений статическим свойствам). В том случае, когда нет явно заданного статического конструктора, класс помечается флагом beforefieldinit, что говорит CLR о том, что инициализация статического поля произойдет до первого обращения к этому полю, причем она может произойти задолго до этого обращения.",
                                     SortKey = 1,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Один раз при первом упоминании экземпляра класса или при первом обращении к статическим членам класса",
                                                SortKey = 1,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "После каждого обращения к статическим полям, методам и свойствам",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Строгий порядок вызова не определен",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Статических конструкторов в C# нет",
                                                SortKey = 4,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Каким образом можно перезватить добавление и удаление делегата события ?",
                                     Description = "Для подобных целей в C# предусмотрены ключевые слова add и remove. Их необходимо использовать аналогично get и set для свойств.",
                                     SortKey = 2,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Такая возможность не предусмотрена",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Для этого существует специальные ключевые слова add и remove",
                                                SortKey = 2,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Использовать ключевые слова get и set",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Переопределить операторы + и - для делегата",
                                                SortKey = 4,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Что произойдет при исполнении следующего кода? Int i =5; object o = i; long j = (long)o;",
                                     Description = "Будет сгенерировано исключение InvalidCastException (Исключение, которое выбрасывается при недопустимом приведении или явном преобразовании типов). Ошибка находится в третьей строчке. Для того чтобы исправить ошибку достаточно изменить третью строчку long j = (int)o; Сначала будет произведен unboxing и возвращена переменная типа int, после чего будет вызван соответствующий implicit оператор.",
                                     SortKey = 3,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Ошибка не произойдет. Переменная j будет иметь значение 5",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Произойдет ошибка компиляции",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Средой исполнения будет вызвано исключение InvalidCastException",
                                                SortKey = 3,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Значение переменной j предсказать нельзя",
                                                SortKey = 4,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Реализацией какого паттерна (шаблона проектирования) являются события в C# ?",
                                     Description = "Рассмотрим пример с кнопкой. Создав объект класса Button, мы подписываемся на его событие Click, которые происходит при нажатии на кнопку. В данном случае, объект Button является издателем (publisher), а тот метод, который подписан на событие, соответственно, подписчиком (subscriber).",
                                     SortKey = 4,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Декоратор (Decorator)",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Издатель подписчик (Publisher-Subscriber)",
                                                SortKey = 2,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Посетитель (Visitor)",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Шаблонный метод (Template Method)",
                                                SortKey = 4,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Что произойдет при компиляции проекта, где используется класс, структура, интерфейс или перечисление, помеченное аттрибутом Obsolete",
                                     Description = "Существует специальное пространство System.Runtime.InteropServices, в котором находятся классы для работы с неуправляемым кодом, например, хорошо известный атрибут DllImport, для подключения DLL-функций.",
                                     SortKey = 7,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Произойдет ошибка компиляции и проект не будет собран",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Будет выведено предупреждение о том, что данный тип устарел, но сборка будет создана",
                                                SortKey = 2,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Нет нужного варианта ответа",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Аттрибут Obsolete никак не влияет на компиляцию",
                                                SortKey = 4,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 }
                            },
                            Questions_SetOrder =
                                new List<MQuestion_SetOrderDb>()
                                {
                                     new MQuestion_SetOrderDb()
                                     {
                                         QuestionText = "Расставьте в правильном порядке: ",
                                         SortKey = 5,
                                         AnswerVariants =
                                            new List<MAnswerVariant_SetOrderDb>()
                                            {
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "IKernel",
                                                    SortKey = 1,
                                                    CorrectOrderKey = 1
                                                },
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "kernel = ",
                                                    SortKey = 2,
                                                    CorrectOrderKey = 2
                                                },
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "(IKernel)",
                                                    SortKey = 3,
                                                    CorrectOrderKey = 3
                                                },
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "config.",
                                                    SortKey = 4,
                                                    CorrectOrderKey = 4
                                                },
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "DependencyResolver.",
                                                    SortKey = 5,
                                                    CorrectOrderKey = 5
                                                },
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "GetService",
                                                    SortKey = 6,
                                                    CorrectOrderKey = 6
                                                },
                                                new MAnswerVariant_SetOrderDb()
                                                {
                                                    AnswerText = "(typeof(IKernel))",
                                                    SortKey = 7,
                                                    CorrectOrderKey = 7
                                                }
                                            }
                                     }
                                },
                        User_TestAuthor = User_TestAuthor,
                    },
                    new MTest_MainInfoDb()
                    {
                        Name = "Решите ли вы 10 задач на смекалку?",
                        Description = "Тест, определяющий ваш уровень смекалки на основе решения базовых задач",
                        DateCreate = DateTime.Now,
                        Questions_ChoosingAnswerFromList =
                            new List<MQuestion_ChoosingAnswerFromListDb>()
                            {
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Начнём с простейшего. Отгадайте загадку! Странный дождь порой идет: сотней струй он кверху бьет.",
                                     Description = "Не расстраивайтесь, сейчас разогреем вашу смекалку",
                                     SortKey = 0,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Душ",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Лейка",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Фонтан",
                                                SortKey = 3,
                                                IsCorrectAnswer = true
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Чем больше из неё берёшь, тем больше она становится.",
                                     Description = "Вам стоит поднапрячься в дальнейшем!",
                                     SortKey = 1,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Душа",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Яма",
                                                SortKey = 2,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Корзина",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "У отца Мэри есть 5 дочерей: Чача, Чичи, Чече, Чочо. Как зовут 5 дочь?",
                                     Description = "Пойдемте, я познакомлю Вас с настоящей чачей)",
                                     SortKey = 2,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Чучу",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Мэри",
                                                SortKey = 2,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Чючю",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "На столе лежит яблоко. Его разделили на 4 части. Сколько яблок лежит на столе?",
                                     Description = "Мы делили апельсин...много наших полегло. Это высказывание, видимо, про Вас! =)",
                                     SortKey = 3,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Два",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Четыре",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Одно",
                                                SortKey = 3,
                                                IsCorrectAnswer = true
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Чем оканчиваются день и ночь? ",
                                     Description = "Похоже, Вы все еще не успели открыть глаза",
                                     SortKey = 4,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Часами",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Сном",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Мягким знаком",
                                                SortKey = 3,
                                                IsCorrectAnswer = true
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Что принадлежит вам, однако другие им пользуются чаще, чем вы? ",
                                     Description = "Зато мании величия у вас нет",
                                     SortKey = 5,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Ваши деньги",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Ваше имя",
                                                SortKey = 2,
                                                IsCorrectAnswer = true
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Ваши руки",
                                                SortKey = 3,
                                                IsCorrectAnswer = false
                                            }
                                        }
                                 },
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Каких камней в море нет?",
                                     Description = "Мы делили апельсин...много наших полегло. Это высказывание, видимо, про Вас! =)",
                                     SortKey = 6,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Янтаря",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Квадратных",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Сухих",
                                                SortKey = 3,
                                                IsCorrectAnswer = true
                                            }
                                        }
                                 }
                            },
                        Questions_SetOrder =
                            new List<MQuestion_SetOrderDb>()
                            {
                                 new MQuestion_SetOrderDb()
                                 {
                                     QuestionText = "",
                                     SortKey = 11,
                                     AnswerVariants =
                                        new List<MAnswerVariant_SetOrderDb>()
                                        {
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 1,
                                                CorrectOrderKey = 1
                                            },
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 2,
                                                CorrectOrderKey = 2
                                            },
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 3,
                                                CorrectOrderKey = 3
                                            },
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 4,
                                                CorrectOrderKey = 4
                                            },
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 5,
                                                CorrectOrderKey = 5
                                            },
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 6,
                                                CorrectOrderKey = 6
                                            },
                                            new MAnswerVariant_SetOrderDb()
                                            {
                                                AnswerText = "",
                                                SortKey = 7,
                                                CorrectOrderKey = 7
                                            }
                                        }
                                 }
                            },
                        User_TestAuthor = User_TestAuthor
                    }
                 };

            context.Test_MainInfo.AddRange(default_Test_MainInfoDb);

            // ------------ 

            base.Seed(context);
        }
    }
}