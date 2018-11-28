import axios from 'axios';
export function request(url, options) {
    // performs api calls sending the required authentication headers
    const headers = {
        'Accept': 'application/json',
        'content-type': 'application/json;charset=utf-8',
    }

    // Setting Authorization header
    // Authorization: Bearer xxxxxxx.xxxxxxxx.xxxxxx
    const token = localStorage.getItem('id_token')
    if (token) {
        console("add token to header");
        headers['Authorization'] = 'Bearer ' + token
    }

    return fetch(url, {
        headers,
        ...options
    })
        .then(this._checkStatus)
        .then(response => response.json())
}

export function get(url) {
    let options = {
        method: 'GET',
        url: url,
        headers: {}
    }

    const token = localStorage.getItem('id_token')
    if (token) {
        options.headers['Authorization'] = 'Bearer ' + token;
    }

    const response = axios(options);
    return response.then(res => { return res.data });
}