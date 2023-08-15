using CoreLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string message): this(success)
        {
            MyMessage= message;
        }
        public Result(bool success)
        {
            IsSuccess= success;
        }
        public bool IsSuccess { get;}

        public string MyMessage { get; }
    }
}
