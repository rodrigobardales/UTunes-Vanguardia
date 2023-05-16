﻿using Microsoft.AspNetCore.Mvc;
using UTunes.Core;

namespace UTunes.Api.Controllers
{
    public class UTunesBaseController : ControllerBase
    {
        protected ActionResult GetErrorResult<TRestult>(OperationResult<TRestult> result)
        {
            switch (result.Error.Code)
            {
                case Core.ErrorCode.NotFound:
                    return NotFound(result.Error.Message);
                case Core.ErrorCode.Unauthorized:
                    return Unauthorized(result.Error.Message);
                default:
                    return BadRequest(result.Error.Message);
            }
        }
    }
}
