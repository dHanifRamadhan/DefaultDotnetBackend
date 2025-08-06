
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using DefaultDotnetBackend.DTOs;

namespace DefaultDotnetBackend.Controller { 
    public class BaseController : ControllerBase {
        // Success Response
        protected IActionResult Ok (string? message = null) => base.Ok(new ApiResponse{
            Success = true,
            Message = message ?? Messages.OK,
        });

        protected IActionResult Ok<T> (T data, string? message = null) => base.Ok(new ApiResponse<T>{
            Success = true,
            Message = message ?? Messages.OK,
            Data = data,
        });

        protected IActionResult Created<T>(string url, T data, string? message = null) => base.Created(url, new ApiResponse<T>{
            Success = true,
            Message = message ?? Messages.OK_CREATED,
            Data = data,
        });

        // TODO: untuk response update dengan data
        protected IActionResult Updated<T>(string url, T data, string? message = null) => base.Created(url, new ApiResponse<T> {
            Success = true,
            Message = message ?? Messages.OK_UPDATED,
            Data = data,
        });

        // TODO: untuk response update & delete tanpa data
        protected IActionResult NoContent(string? message = null) => base.NoContent();

        protected IActionResult Paged<T>(PagedResult<T> data, int page, int pageSize, string? message = null) => base.Ok(
            new PagedResponse<T> {
                Success = true,
                Message = message ?? Messages.OK_RETRIEVED,
                Data = data.Data,
                Meta = new PagedMetaResponse {
                    TotalItems = data.TotalItems,
                    TotalPages = (int)Math.Ceiling(data.TotalItems / (double)pageSize),
                    CurrentPage = page,
                    PageSize = pageSize,
                }
            }
        );

        // Error Client Response
        protected IActionResult BadRequest(string? message = null) => base.BadRequest(new {
            Success = false,
            Message = message ?? Messages.WARN_VALIDATION,
            Errors = (object?)null,
        });

        protected IActionResult BadRequest(ModelStateDictionary item, string? message = null) => base.BadRequest(
            new ApiValidationResponse {
                Success = false,
                Message = message ?? Messages.WARN_VALIDATION,
                Errors = item
                    .Where(e => e.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray())
            }
        );

        protected IActionResult Unauthorized(string? message = null) => base.Unauthorized(new ApiResponse
            {
                Success = false,
                Message = message ?? Messages.ERR_UNAUTHORIZED,
            }
        );

        protected IActionResult Forbidden(string? message = null) => base.Forbid();

        protected IActionResult NotFound(string? message = null) => base.NotFound(new ApiResponse {
            Success = false,
            Message = message ?? Messages.WARN_NOT_FOUND,
        });

        protected IActionResult Conflict(string? message = null) => base.Conflict(new ApiResponse {
            Success = false,
            Message = message ?? Messages.WARN_DUPLICATE,
        });

        // Error Server Response
        protected IActionResult InternalServerError(Exception? ex = null) {
            var response = new ApiResponse
            {
                Success = false,
                Message = Messages.EXCEPTION_INTERNALL_SERVER
            };

            if (ex != null && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                response.Details = ex.Message;
                response.StackTrace = ex.StackTrace;
            }

            return StatusCode(500, response);
        }

        protected IActionResult FileResponse(byte[] fileBytes, string fileName, string contentType)
        {
            Response.Headers.Append("Content-Disposition", $"attachment; filename=\"{fileName}\"");
            return File(fileBytes, contentType);
        }
    }
}