using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testes.Bench
{
    public class FuncoesMatematicas
    {
        [Params(1000)]
        public double Number { get; set; }

        [Benchmark]
        public double NumeroAoQuadrado()
        {
            return this.Number * this.Number;
        }

        [Benchmark]
        public double NumeroAoQuadradoMathPow()
        {
            return Math.Pow(this.Number, 2);
        }
    }

    [MemoryDiagnoser]
    [CsvExporter]
    [CsvMeasurementsExporter]
    public class ExceptionValidation
    {
        public int ValidationCount = 100;
        public List<Error> HayStack => new List<Error>();
        public ExceptionValidation()
        {
            for (int i = 0; i < ValidationCount; i++)
            {
                HayStack.Add(new Error(new List<ErrorMessage>() { new ErrorMessage() { Tag = "123", Message = "Mensagem de teste" } }));
            }
        }

        [Benchmark]
        public void ErrorWithException()
        {
            try
            {
                throw new ValidateException(new Error(new List<ErrorMessage>() { new ErrorMessage() { Tag = "123", Message = "Mensagem de teste" } }));
            }
            catch(Exception)
            {
            }
            
        }

        [Benchmark]
        public Error ErrorWithoutException()
        {
            return new Error(new List<ErrorMessage>() { new ErrorMessage() { Tag = "123", Message = "Mensagem de teste" } });
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExceptionValidation>();
            Console.ReadLine();
        }
    }
}
