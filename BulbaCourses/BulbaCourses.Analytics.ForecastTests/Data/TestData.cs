using System;
using System.Collections.Generic;

namespace Forecast.Tests
{
    public static class TestData
    {
        public static IEnumerable<double> DataDoubles()
        {
            IEnumerable<double> dataDoubles = new double[]
            {
                92619,
                97948,
                99593,
                93251,
                94839,
                97591,
                90192,
                95690,
                103223,
                102629,
                105591,
                117227

            };
            return dataDoubles;
        }

        public static Data[] Data()
        {
            var data = new Data[]
            {
                new Data(DateTime.Parse("01.01.2017"), 56769),
                new Data(DateTime.Parse("01.02.2017"), 63451),
                new Data(DateTime.Parse("01.03.2017"), 53020),
                new Data(DateTime.Parse("01.04.2017"), 58543),
                new Data(DateTime.Parse("01.05.2017"), 59696),
                new Data(DateTime.Parse("01.06.2017"), 58945),
                new Data(DateTime.Parse("01.07.2017"), 60605),
                new Data(DateTime.Parse("01.08.2017"), 70814),
                new Data(DateTime.Parse("01.09.2017"), 57822),
                new Data(DateTime.Parse("01.10.2017"), 64363),
                new Data(DateTime.Parse("01.11.2017"), 66207),
                new Data(DateTime.Parse("01.12.2017"), 53837),
                new Data(DateTime.Parse("01.01.2018"), 68521),
                new Data(DateTime.Parse("01.02.2018"), 63779),
                new Data(DateTime.Parse("01.03.2018"), 63135),
                new Data(DateTime.Parse("01.04.2018"), 63113),
                new Data(DateTime.Parse("01.05.2018"), 69929),
                new Data(DateTime.Parse("01.06.2018"), 68322),
                new Data(DateTime.Parse("01.07.2018"), 68770),
                new Data(DateTime.Parse("01.08.2018"), 71064),
                new Data(DateTime.Parse("01.09.2018"), 71305),
                new Data(DateTime.Parse("01.10.2018"), 70360),
                new Data(DateTime.Parse("01.11.2018"), 68905),
                new Data(DateTime.Parse("01.12.2018"), 71018),
                new Data(DateTime.Parse("01.01.2019"), 74293),
                new Data(DateTime.Parse("01.02.2019"), 89200),
                new Data(DateTime.Parse("01.03.2019"), 94255),
                new Data(DateTime.Parse("01.04.2019"), 93417),
                new Data(DateTime.Parse("01.05.2019"), 91780),
                new Data(DateTime.Parse("01.06.2019"), 94707),
                new Data(DateTime.Parse("01.07.2019"), 98981),
                new Data(DateTime.Parse("01.08.2019"), 98906)

            };
            return data;
        }
    }
}
