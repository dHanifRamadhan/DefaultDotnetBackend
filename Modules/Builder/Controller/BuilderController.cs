using System.IO.Compression;
using DefaultDotnetBackend.DTOs;
using DefaultDotnetBackend.Repositories;
using DefaultDotnetBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace DefaultDotnetBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuilderController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IBuilderService _builderService;
        private readonly ILogger<BuilderController> _logger;
        private const string TAG = "[BuilderController]: {x}";
        public BuilderController(
            IConfiguration configuration,
            IBuilderService builderService,
            ILogger<BuilderController> logger
        )
        {
            _configuration = configuration;
            _builderService = builderService;
            _logger = logger;
        }

        [HttpGet("Schema")]
        public async Task<IActionResult> GetSchema()
        {
            try
            {
                var schema = await _builderService.GetAllSchema();
                if (schema?.Data?.Count == 0) return NotFound();
                return Ok(schema);
            }
            catch (Exception e)
            {
                _logger.LogError(TAG, e);
                return BadRequest(Constants.Messages.EXCEPTION_INTERNALL_SERVER);
            }
        }

        [HttpGet("Table")]
        public async Task<IActionResult> GetTable([FromQuery] string schema)
        {
            try
            {
                var tables = await _builderService.GetAllTable(schema);
                if (tables?.Data?.Count == 0) return NotFound();
                return Ok(tables);
            }
            catch (Exception e)
            {
                _logger.LogError(TAG, e);
                return BadRequest(Constants.Messages.EXCEPTION_INTERNALL_SERVER);
            }
        }

        [HttpGet("Table/Detail")]
        public async Task<IActionResult> GetTableByName(
            [FromQuery] string schema,
            [FromQuery] string tableName
        )
        {
            try
            {
                var table = await _builderService.GetTableByName(schema, tableName);
                if (table == null) return NotFound();
                return Ok(table);
            }
            catch (Exception e)
            {
                _logger.LogError(TAG, e);
                return BadRequest(Constants.Messages.EXCEPTION_INTERNALL_SERVER);
            }
        }

        [HttpPost("Generate")]
        public async Task<IActionResult> BuilderGenerate([FromBody] BuilderRequest item)
        {
            try
            {
                var table = await _builderService.GetTableByName(item.Schema, item.TableName);
                var code = await _builderService.GenerateEntity(
                    item.Schema,
                    item.TableName,
                    item.Namespace
                );

                // // 2. Tentukan folder sementara
                // var tempFolder = Path.Combine(Path.GetTempPath(), $"gen_{Guid.NewGuid()}");
                // Directory.CreateDirectory(tempFolder);

                // // 3. Simpan file .cs ke folder
                // var filePath = Path.Combine(tempFolder, $"{table.TableName}.cs");
                // System.IO.File.WriteAllText(filePath, code);

                // // 4. Buat file ZIP
                // var zipPath = Path.Combine(Path.GetTempPath(), $"{table.TableName}.zip");
                // if (System.IO.File.Exists(zipPath))
                //     System.IO.File.Delete(zipPath);

                // ZipFile.CreateFromDirectory(tempFolder, zipPath);

                // // 5. Baca zip untuk dikirim
                // var zipBytes = System.IO.File.ReadAllBytes(zipPath);

                // // 6. Bersihkan folder sementara
                // Directory.Delete(tempFolder, true);
                // System.IO.File.Delete(zipPath);

                // 7. Return file ZIP ke client
                // return File(zipBytes, "application/zip", $"{table.TableName}.zip");

                var fileName = $"{table.TableName}.cs";
                var fileBytes = System.Text.Encoding.UTF8.GetBytes(code);

                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception e)
            {
                _logger.LogError(TAG, e);
                return BadRequest(Constants.Messages.EXCEPTION_INTERNALL_SERVER);
            }
        }
    }
}