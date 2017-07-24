﻿using System;
using System.Collections.Generic;
using Domain.Interfaces;
using ImaginariumCore.Contracts;
using ImaginariumCore.Contracts.Input;
using ImaginariumCore.Contracts.Output;
using ImaginariumCore.Contracts.Output.Stages;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImaginariumCore.Controllers
{
    public class LobbyController : Controller
    {
        private ILobbyManager _lobbyManager;
        private ContractMapper _contractMapper;

        public LobbyController(ILobbyManager lobbyManager , ContractMapper contractMapper)
        {
            _lobbyManager = lobbyManager;
            _contractMapper = contractMapper;
        }

        [Route("join")]
        [HttpPut]
        public LobbyTokenValueObject JoinToLobby([FromBody] JoiningToLobby joiningToLobby)
        {
            return _contractMapper.WrapToken(
                _lobbyManager.AddPlayer(joiningToLobby.PlayerToken,
                joiningToLobby.GameType,joiningToLobby.Size,joiningToLobby.NickName));
        }

        [Route("update")]
        [HttpPut]
        public UpdatedLobby UpdateLobby([FromBody] LobbyTokenValueObject lobbyToken)
        {
            return _contractMapper.ToUpdate(_lobbyManager.UpdateLobby(lobbyToken.LobbyToken));
        }

        [Route("all/get")]
        [HttpGet]
        public IList<ILobby> GetAll()
        {
            return _lobbyManager.GetAll();
        }

        [Route("all/clear")]
        [HttpGet]
        public IActionResult ClearAll()
        {
            _lobbyManager.ClearAll();
            return Ok("cleared");
        }

        [Route("stage")]
        [HttpPut]
        public IWrapper GetLobbyData([FromBody] Tokens tokens)
        {
            return _contractMapper.MapToStageData(tokens.PlayerToken,_lobbyManager.GetLobby(tokens.LobbyToken));
        }


    }
}