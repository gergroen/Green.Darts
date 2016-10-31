$(function () {

    var webApiClient = {
        startNewGame: function () {
            $.ajax({
                type: "POST",
                data: JSON.stringify({ Name: 'Game1' }),
                url: '/api/game/StartNewGame',
                contentType: "application/json"
            });
        },
        getGame: function (id, done) {
            $.getJSON("/api/game/get?id=" + id, function (result) {
                done(result);
            });
        },
        getAllGames: function (done) {
            $.getJSON("/api/game/getall", function (result) {
                done(result);
            });
        },
        createNewPlayer: function () {
            $.ajax({
                type: "POST",
                data: JSON.stringify({ Name: 'Player1' }),
                url: '/api/player/CreateNewPlayer',
                contentType: "application/json"
            });
        },
        getPlayer: function (id, done) {
            $.getJSON("/api/player/get?id=" + id, function (result) {
                done(result);
            });
        },
        getAllPlayers: function (done) {
            $.getJSON("/api/player/getall", function (result) {
                done(result);
            });
        }
    };

    var viewmodel = {
        games: ko.observableArray(),
        players: ko.observableArray(),
        connectionState: ko.observable('disconnected'),
        onStartNewGameButtonClicked: function () {
            webApiClient.startNewGame();
        },
        onCreateNewPlayerButtonClicked: function () {
            webApiClient.createNewPlayer();
        }
    };

    var controller = {
        onNewGameStartedEvent: function (newGameStartedEvent) {
            webApiClient.getGame(newGameStartedEvent.GameId, function (result) {
                viewmodel.games.push(result);
            });
        },
        onNewPlayerCreatedEvent: function (newPlayerCreatedEvent) {
            webApiClient.getPlayer(newPlayerCreatedEvent.PlayerId, function (result) {
                viewmodel.players.push(result);
            });
        },
        onSignalRConnectionStateChanged: function (state) {
            var stateConversion = { 0: 'connecting', 1: 'connected', 2: 'reconnecting', 4: 'disconnected' };
            viewmodel.connectionState(stateConversion[state.newState]);
        },
        onSignalRConnected: function () {
            webApiClient.getAllPlayers(function (result) {
                viewmodel.players(result);
            });
            webApiClient.getAllGames(function (result) {
                viewmodel.games(result);
            });
        },
        onSignalRDisconnected: function () {
            setTimeout(function () {
                connection.start().done(controller.onSignalRConnected);
            }, 5000);
        }
    };

    var connection = $.hubConnection();
    var gameHub = connection.createHubProxy('GameHub');
    var playerHub = connection.createHubProxy('PlayerHub');
    gameHub.on('NewGameStartedEvent', controller.onNewGameStartedEvent);
    playerHub.on('NewPlayerCreatedEvent', controller.onNewPlayerCreatedEvent);

    connection.disconnected(controller.onSignalRDisconnected);
    connection.reconnected(controller.onSignalRConnected)
    connection.stateChanged(controller.onSignalRConnectionStateChanged);
    connection.start().done(controller.onSignalRConnected);

    ko.applyBindings(viewmodel);
});