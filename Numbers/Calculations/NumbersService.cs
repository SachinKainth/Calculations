using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calculations
{
    public class NumbersService
    {
        private readonly string _filePath;

        public NumbersService(string filePath)
        {
            _filePath = filePath;
        }

        public IList<decimal> ReadNumbers()
        {
            try
            {
                using (var reader = new StreamReader(_filePath))
                {
                    var data = reader.ReadToEnd();
                    return ReadNumbers(data);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException($"The file {_filePath} is invalid.", e);
            }
            catch (FormatException e)
            {
                throw new CorruptFileException($"The file {_filePath} contains invalid data.", e);
            }
        }

        private IList<decimal> ReadNumbers(string data)
        {
            var strings = data.Split(',');
            return strings.Select(decimal.Parse).ToList();
        }
    }
}