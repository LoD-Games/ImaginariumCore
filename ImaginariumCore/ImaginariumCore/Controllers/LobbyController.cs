using System;
using System.Collections.Generic;
using Domain.Interfaces;
using ImaginariumCore.Contracts;
using ImaginariumCore.Contracts.Input;
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
        public Guid JoinToLobby([FromBody] JoiningToLobby joiningToLobby)
        {
            return _lobbyManager.AddPlayer(joiningToLobby.PlayerToken,joiningToLobby.GameType,joiningToLobby.Size);
        }

        [Route("update")]
        [HttpPut]
        public IList<string> UpdateLobby([FromBody] Guid lobbyToken)
        {
            return _contractMapper.ToUpdate(_lobbyManager.UpdateLobby(lobbyToken));
        }

    }
}