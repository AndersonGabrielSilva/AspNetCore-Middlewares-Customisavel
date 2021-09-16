using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Middlewares_Customisavel_DEMO._6___Padronizando_erros_Middlewares.ViewModel
{
    public class ErrorResponseViewModel
    {
        #region Costrutores
        public ErrorResponseViewModel()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsViewModel>();
        }

        public ErrorResponseViewModel(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsViewModel>();
            AddError(logref, message);
        }
        #endregion

        public string TraceId { get; set; }
        public List<ErrorDetailsViewModel> Errors { get; set; }

        #region Metodos
        public void AddError(string logRef, string message)
        {
            Errors.Add(new ErrorDetailsViewModel(logRef, message));
        }
        #endregion
    }

    public class ErrorDetailsViewModel 
    {
        public ErrorDetailsViewModel(string logref, string message)
        {
            Logref = logref;
            Message = message;
        }

        public string Logref { get; set; }
        public string Message { get; set; }
    }

}
