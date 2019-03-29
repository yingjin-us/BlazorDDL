using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorDDL.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDDL.Client.Pages
{
    public class ServerTypesModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }
        protected List<BlazorDDL.Shared.Models.ServerTypes> serverTypesList = new List<BlazorDDL.Shared.Models.ServerTypes>();
        protected List<Servers> serverList = new List<Servers>();

        protected string serverTypesId { get; set; }
        protected string serverTypesName { get; set; }
        protected string serverName { get; set; }

        protected override async Task OnInitAsync()
        {
            serverTypesList = await Http.GetJsonAsync<List<BlazorDDL.Shared.Models.ServerTypes>>("api/ServerTypes/GetServerTypesList");
        }

        protected async void ServerTypesClicked(UIChangeEventArgs serverTypeEvent)
        {
            serverList.Clear();
            serverName = string.Empty;

            serverTypesId = serverTypeEvent.Value.ToString();
            serverTypesName = serverList.FirstOrDefault(s => s.ServerTypeId == Int64.Parse(serverTypesId)).Name;

            serverList = await Http.GetJsonAsync<List<Servers>>("api/ServerTypes/GetServers/" + serverTypesId);
            this.StateHasChanged();
        }

        protected void ServerClicked(UIChangeEventArgs serverEvent)
        {
            serverName = serverEvent.Value.ToString();
            this.StateHasChanged();
        }
    }
}