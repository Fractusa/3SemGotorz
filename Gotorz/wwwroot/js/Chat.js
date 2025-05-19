window.chatClient = {
    connection: null,
    start: (userName, dotnetRef) => {
        window.chatClient.connection = new signalR.HubConnectionBuilder()
            .withUrl("/chathub")
            .withAutomaticReconnect()
            .build();

        window.chatClient.connection.on("ReceiveMessage", msg =>
            dotnetRef.invokeMethodAsync("ReceiveMessageFromHub", msg)
        );

        return window.chatClient.connection.start();
    },
    send: (userName, text) =>
        window.chatClient.connection.invoke("SendMessage", userName, text)
};