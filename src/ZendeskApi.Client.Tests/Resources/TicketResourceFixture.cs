﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using ZendeskApi.Client.Resources;

namespace ZendeskApi.Client.Tests.Resources
{
    public class TicketResourceFixture : IDisposable
    {
        private readonly IZendeskApiClient _client;
        private readonly TicketResource _resource;

        public TicketResourceFixture()
        {
            _client = new DisposableZendeskApiClient();
            _resource = new TicketResource(_client);
        }

        [Fact]
        public async Task ShouldCreateTicket()
        {
            var response = await _resource.PostAsync(
                new Contracts.Requests.TicketRequest
                {
                    Item = new Contracts.Models.Ticket
                    {
                        Subject = "My printer is on fire!",
                        Comment = new Contracts.Models.TicketComment
                        {
                            Body = "The smoke is very colorful."
                        }
                    }
                });

            var item = response.Item;

            Assert.NotNull(item.Id);
            Assert.Equal("My printer is on fire!", item.Subject);
            Assert.Equal("The smoke is very colorful.", item.Comment.Body);
        }

        public void Dispose()
        {
            ((IDisposable)_client).Dispose();
        }

        //[Fact]
        //public void Get_Called_CallsBuildUriWithFieldId()
        //{
        //    // Given
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), It.Is<string>(s => s.Contains("321")))).Returns(new Uri("http://search"));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    ticketResource.Get(321);

        //    // Then
        //    _client.Verify(c => c.BuildUri(It.Is<string>(s => s.Contains("321")), ""));
        //}

        //[Fact]
        //public async Task GetAsync_Called_CallsBuildUriWithFieldId()
        //{
        //    // Given
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), It.Is<string>(s => s.Contains("321")))).Returns(new Uri("http://search"));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    await ticketResource.GetAsync(321);

        //    // Then
        //    _client.Verify(c => c.BuildUri(It.Is<string>(s => s.Contains("321")), ""));
        //}

        //[Fact]
        //public void Get_Called_ReturnsTicketResponse()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Id = 1 } };
        //    _client.Setup(b => b.Get<TicketResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(response);
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = ticketResource.Get(321);

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public async Task GetAsync_Called_ReturnsTicketResponse()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Id = 1 } };
        //    _client.Setup(b => b.GetAsync<TicketResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(TaskHelper.CreateTaskFromResult(response));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = await ticketResource.GetAsync(321);

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public void GetAll_Called_CallsBuildUriWithFieldId()
        //{
        //    // Given
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), It.IsAny<string>())).Returns(new Uri("http://search"));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    ticketResource.GetAll(new List<long> { 321, 456, 789 });

        //    // Then
        //    _client.Verify(c => c.BuildUri(It.Is<string>(s => s.Contains("/show_many")), It.IsAny<string>()));
        //}

        //[Fact]
        //public async Task GetAllAsync_Called_CallsBuildUriWithFieldId()
        //{
        //    // Given
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), It.IsAny<string>())).Returns(new Uri("http://search"));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    await ticketResource.GetAllAsync(new List<long> { 321, 456, 789 });

        //    // Then
        //    _client.Verify(c => c.BuildUri(It.Is<string>(s => s.Contains("/show_many")), It.IsAny<string>()));
        //}

        //[Fact]
        //public void GetAll_Called_ReturnsTicketResponse()
        //{
        //    // Given
        //    var response = new TicketListResponse { Results = new List<Ticket> { new Ticket { Id = 1 } } };
        //    _client.Setup(b => b.Get<TicketListResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(response);
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = ticketResource.GetAll(new List<long> { 321, 456, 789 });

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public async Task GetAllAsync_Called_ReturnsTicketResponse()
        //{
        //    // Given
        //    var response = new TicketListResponse { Results = new List<Ticket> { new Ticket { Id = 1 } } };
        //    _client.Setup(b => b.GetAsync<TicketListResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(TaskHelper.CreateTaskFromResult(response));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = await ticketResource.GetAllAsync(new List<long> { 321, 456, 789 });

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public void Put_Called_BuildsUri()
        //{
        //    // Given
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah", Id = 123 } };
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    ticketResource.Put(request);

        //    // Then
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), ""));
        //}

        //[Fact]
        //public async Task PutAsync_Called_BuildsUri()
        //{
        //    // Given
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah", Id = 123 } };
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    await ticketResource.PutAsync(request);

        //    // Then
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), ""));
        //}

        //[Fact]
        //public void Put_CalledWithTicket_ReturnsTicketReponse()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Subject = "blah blah" } };
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah", Id = 123 } };
        //    _client.Setup(b => b.Put<TicketResponse>(It.IsAny<Uri>(), request, "application/json", It.IsAny<string>(), It.IsAny<string>())).Returns(response);
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = ticketResource.Put(request);

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public async Task PutAsync_CalledWithTicket_ReturnsTicketReponse()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Subject = "blah blah" } };
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah", Id = 123 } };
        //    _client.Setup(b => b.PutAsync<TicketResponse>(It.IsAny<Uri>(), request, "application/json", It.IsAny<string>(), It.IsAny<string>())).Returns(TaskHelper.CreateTaskFromResult(response));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = await ticketResource.PutAsync(request);

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public void Put_TicketHasNoId_ThrowsException()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Subject = "blah blah" } };
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah" } };
        //    _client.Setup(b => b.Put<TicketResponse>(It.IsAny<Uri>(), request, "application/json", It.IsAny<string>(), It.IsAny<string>())).Returns(response);
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When, Then
        //    Assert.Throws<ArgumentException>(() => ticketResource.Put(request));
        //}

        //[Fact]
        //public void PutAsync_TicketHasNoId_ThrowsException()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Subject = "blah blah" } };
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah" } };
        //    _client.Setup(b => b.PutAsync<TicketResponse>(It.IsAny<Uri>(), request, "application/json", It.IsAny<string>(), It.IsAny<string>())).Returns(TaskHelper.CreateTaskFromResult(response));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When, Then
        //    Assert.Throws<ArgumentException>(async () => await ticketResource.PutAsync(request));
        //}

        //[Fact]
        //public void Post_Called_BuildsUri()
        //{
        //    // Given
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah" } };
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    ticketResource.Post(request);

        //    // Then
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), ""));
        //}

        //[Fact]
        //public async Task PostAsync_Called_BuildsUri()
        //{
        //    // Given
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah" } };
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    await ticketResource.PostAsync(request);

        //    // Then
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), ""));
        //}

        //[Fact]
        //public void Post_CalledWithTicket_ReturnsTicketReponse()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Subject = "blah blah" } };
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah" } };
        //    _client.Setup(b => b.Post<TicketResponse>(It.IsAny<Uri>(), request, "application/json", It.IsAny<string>(), It.IsAny<string>())).Returns(response);
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = ticketResource.Post(request);

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public async Task PostAsync_CalledWithTicket_ReturnsTicketReponse()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Subject = "blah blah" } };
        //    var request = new TicketRequest { Item = new Ticket { Subject = "blah blah" } };
        //    _client.Setup(b => b.PostAsync<TicketResponse>(It.IsAny<Uri>(), request, "application/json", It.IsAny<string>(), It.IsAny<string>())).Returns(TaskHelper.CreateTaskFromResult(response));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    var result = await ticketResource.PostAsync(request);

        //    // Then
        //    Assert.Equal(response, result);
        //}

        //[Fact]
        //public void Delete_Called_CallsBuildUriWithFieldId()
        //{
        //    // Given
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), It.Is<string>(s => s.Contains("321")))).Returns(new Uri("http://search"));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    ticketResource.Delete(321);

        //    // Then
        //    _client.Verify(c => c.BuildUri(It.Is<string>(s => s.Contains("321")), ""));
        //}

        //[Fact]
        //public async Task DeleteAsync_Called_CallsBuildUriWithFieldId()
        //{
        //    // Given
        //    _client.Setup(b => b.BuildUri(It.IsAny<string>(), It.Is<string>(s => s.Contains("321")))).Returns(new Uri("http://search"));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    await ticketResource.DeleteAsync(321);

        //    // Then
        //    _client.Verify(c => c.BuildUri(It.Is<string>(s => s.Contains("321")), ""));
        //}

        //[Fact]
        //public void Delete_Called_CallsDeleteOnClient()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Id = 1 } };
        //    _client.Setup(b => b.Get<TicketResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(response);
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    ticketResource.Delete(321);

        //    // Then
        //    _client.Verify(c => c.Delete<object>(It.IsAny<Uri>(), It.IsAny<object>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        //}

        //[Fact]
        //public async Task DeleteAsync_Called_CallsDeleteOnClient()
        //{
        //    // Given
        //    var response = new TicketResponse { Item = new Ticket { Id = 1 } };
        //    _client.Setup(b => b.GetAsync<TicketResponse>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(TaskHelper.CreateTaskFromResult(response));
        //    var ticketResource = new TicketResource(_client.Object);

        //    // When
        //    await ticketResource.DeleteAsync(321);

        //    // Then
        //    _client.Verify(c => c.DeleteAsync<object>(It.IsAny<Uri>(), It.IsAny<object>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        //}
    }
}
