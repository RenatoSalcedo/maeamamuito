import { Component, animate } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Login } from './login';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['../../css/bootstrap.css', '../../css/custom.css']
})

@Injectable()
export class LoginComponent {
    public user: Login;
    public logued: Login;
    url; headers;
    
    constructor(private _http: Http, private _router: Router) {
        this.user = new Login();
    }

    public Logar()
    {
        let bodyString  = JSON.stringify(this.user);
        let headers     = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        let options     = new RequestOptions({ headers: headers }); // Create a request option

        this._http.post('/api/Account/logIn', bodyString, { headers: headers }).
            subscribe(
                data => {
                    this.logued = data.json() as Login;
                    this._router.navigate(['admin/cadastro']);
                }, 
                error => { 
                    console.log(JSON.stringify(error.json()));
                });
    }

    public Deslogar()
    {
        let bodyString  = JSON.stringify(this.user);
        let headers     = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        let options     = new RequestOptions({ headers: headers }); // Create a request option

        this._http.post('/api/Account/logOut', bodyString, { headers: headers }).
            subscribe(
                data => {
                   //this.logued = data.json() as Number;
                }, 
                error => { 
                    console.log(JSON.stringify(error.json()));
                });
    }
}