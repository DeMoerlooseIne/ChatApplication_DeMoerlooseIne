using ChatApplication.Models;
using ChatApplication.Services;
using ChatApplication.Ui.Areas.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TalkApiClient.Ui.WebApp.Areas.Manager.Controllers
{
    public class ChatController : ManagerBaseController
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListChatChannels()
        {
            var channels = await _chatService.GetAllAsync<ChatChannel>("/api/chat-channels");

            return View(channels);
        }

        [HttpGet]
        public IActionResult CreateChatChannel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatChannel(ChatChannel value)
        {
            await _chatService.CreateAsync(value, "/api/chat-channels");

            return RedirectToAction("ListChatChannels");
        }
     
        public async Task<IActionResult> ListChatMessages()
        {
            var messages = await _chatService.GetAllAsync<ChatMessage>("/api/chat-messages");

            return View(messages);
        }

        public IActionResult CreateChatMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatMessage(ChatMessage value)
        {
            await _chatService.CreateAsync(value, "/api/chat-messages");

            return RedirectToAction("ListChatMessages");
        }

        public async Task<IActionResult> MessagesByChannel(string channel)
        {
            var channels = await _chatService.GetAllAsync<ChatChannel>("/api/chat-channels");

            var myChannelsDropDownlist = new SelectList(channels, "Name");
            ViewData["MyChannels"] = myChannelsDropDownlist;

            var messagesFromChannel = await _chatService.GetAllAsync<ChatMessage>("/api/chat-messages?Channel=" + channel);

            return View(messagesFromChannel);
        }
    }
}
