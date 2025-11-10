using DL.Interfaces;
using ML;
using System;
using System.Collections.Generic;

namespace BL
{
    public class Tarea
    {
        private readonly IUnitOfWork _unitOfWork;

        public Tarea(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result GetAll()
        {
            var result = new Result();
            try
            {
                var tareasResult = _unitOfWork.TareaRepository.GetAll();
                if (tareasResult.Correct)
                {
                    result.Objects = tareasResult.Objects; 
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = tareasResult.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Result GetById(int idTarea)
        {
            var result = new Result();
            try
            {
                var tarea = _unitOfWork.TareaRepository.GetById(idTarea);
                if (tarea != null)
                {
                    result.Object = tarea;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Tarea no encontrada";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Result Add(ML.Tarea tarea)
        {
            var result = new Result();
            try
            {
                _unitOfWork.TareaRepository.Add(tarea);
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

        public Result Update(ML.Tarea tarea)
        {
            var result = new Result();
            try
            {
                _unitOfWork.TareaRepository.Update(tarea);
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

        public Result Delete(int idTarea)
        {
            var result = new Result();
            try
            {
                _unitOfWork.TareaRepository.Delete(idTarea);
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
