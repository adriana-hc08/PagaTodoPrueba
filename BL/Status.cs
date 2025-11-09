using DL.Interfaces;
using ML;

namespace BL
{
    public class Status
    {
        private readonly IUnitOfWork _unitOfWork;

        public Status(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result GetAll()
        {
            var result = new Result();
            try
            {
                var statusResult = _unitOfWork.StatusRepository.GetAll();
                if (statusResult.Correct)
                {
                    result.Objects = statusResult.Objects; // Asignar directamente los objetos
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = statusResult.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public Result Add(ML.Status status)
        {
            var result = new Result();
            try
            {
                _unitOfWork.StatusRepository.Add(status);
                _unitOfWork.Save();
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
