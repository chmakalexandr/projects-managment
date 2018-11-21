import decode from 'jwt-decode';

export default class AuthService {
    // Initializing important variables
    constructor(domain) {
        this.state = {
            user: "",
            role: null,
        } 
        this.domain = domain || 'http://localhost:61318/api/Account/' // API server domain
        this.fetch = this.fetch.bind(this) // React binding stuff
        this.login = this.login.bind(this)
        this.getProfile = this.getProfile.bind(this)
        
    }

    login(email, password) {
        
        // Get a token from api server using the fetch api
        return this.fetch(this.domain+'loginin', {
            method: 'POST',
            body: JSON.stringify({
                email: email,
                password: password
            })
        }).then(res => {
            console.log(res);
            
            this.setToken(res.access_token);
            this.setUser(res.userName);
            this.setRole(res.role); // Setting the token in localStorage
            this.user = res.userName;
            this.role = res.role;
            
            return Promise.resolve(res);
        })
    }

    loggedIn() {
        // Checks if there is a saved token and it's still valid
        const token = this.getToken() // GEtting token from localstorage
        console.log("LoggedIn Token is "+token);
        return !!token && !this.isTokenExpired(token) // handwaiving here
    }

    isTokenExpired(token) {
        try {
            const decoded = decode(token);
            if (decoded.exp < Date.now() / 1000) { // Checking if token is expired. N
                return true;
            }
            else
                return false;
        }
        catch (err) {
            return false;
        }
    }

    setToken(idToken) {
        // Saves user token to localStorage
        localStorage.setItem('id_token', idToken);
        console.log("add token to storage: "+localStorage.getItem('id_token'));
    }

    getToken() {
        // Retrieves the user token from localStorage
        console.log("get token from storage: "+localStorage.getItem('id_token'));
        return localStorage.getItem('id_token')
    }

    setUser(userName) {
        // Saves user token to localStorage
        localStorage.setItem('user', userName);
        console.log("add user to storage: "+localStorage.getItem('user'));
    }

    setRole(role) {
        // Saves user token to localStorage
        localStorage.setItem('role', role);
        console.log("add role to storage: "+localStorage.getItem('role'));
    }

   
    getUser() {
        return localStorage.getItem('user')
    }

    getRole() {
        return localStorage.getItem('role')
    }

    logout() {
        // Clear user token and profile data from localStorage
        localStorage.removeItem('id_token');
    }

    getProfile() {
        // Using jwt-decode npm package to decode the token
        return 
    }


    fetch(url, options) {
        // performs api calls sending the required authentication headers
        const headers = {
            'Accept': 'application/json',
            'content-type': 'application/json;charset=utf-8',
        }

        // Setting Authorization header
        // Authorization: Bearer xxxxxxx.xxxxxxxx.xxxxxx
        if (this.loggedIn()) {
            console("add token to header");
            headers['Authorization'] = 'Bearer ' + this.getToken()
        }

        return fetch(url, {
            headers,
            ...options
        })
            .then(this._checkStatus)
            .then(response => response.json())
    }

    _checkStatus(response) {
        // raises an error in case response status is not a success
        if (response.status >= 200 && response.status < 300) { // Success status lies between 200 to 300
            return response
        } else {
            var error = new Error(response.statusText)
            error.response = response
            throw error
        }
    }
}

