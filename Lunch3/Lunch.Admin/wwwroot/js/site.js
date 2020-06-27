// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
_fetch = (url, method, data) => {
    let options = {
        method: method,
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    };

    if (data) options.body = JSON.stringify(data);
    return fetch(url, options)
        .then(res => res.json());
};