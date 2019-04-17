// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener('DOMContentLoaded',
    function() {
        $('.toast').toast('show');

        var connection = new signalR.HubConnectionBuilder()
            .withUrl('/red/signalr')
            .build();

        // Create a function that the hub can call to broadcast messages.
        connection.on('broadcastAlert',
            function(message) {
                console.info(message);
                var alertsDiv = document.getElementById('alerts');
                var toast = document.createElement('div');
                toast.setAttribute('class', 'toast');
                toast.setAttribute('role', 'alert');
                toast.setAttribute('aria-live', 'assertive');
                toast.setAttribute('aria-atomic', 'true');
                toast.setAttribute('data-delay', '10000');
                var header = document.createElement('div');
                header.setAttribute('class', 'toast-header');
                header.innerHTML = '<strong class="mr-auto">Alert</strong>';
                var body = document.createElement('div');
                body.setAttribute('class', 'toast-body');
                body.innerHTML = message;
                toast.appendChild(header);
                toast.appendChild(body);
                alertsDiv.appendChild(toast);
                $(toast).on('hidden.bs.toast',
                    function() {
                        alertsDiv.removeChild(toast);
                    });
                $(toast).toast('show');
            });

        // Transport fallback functionality is now built into start.
        connection.start()
            .then(() => {
            console.log('connection started');
    })
    .catch(error => {
            console.error(error.message);
    });
    });