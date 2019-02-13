import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../_models/User';
import { ok } from 'assert';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    baseUrl = 'https://localhost:5001/api/auth/';

constructor(private http: HttpClient) { }

login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
    .pipe(
        map((response: any) => {
            const user = response;
            if (user) {
                localStorage.setItem('token', user.token);
            }
        })
    );
}

register(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
}

checkUsernameNotTaken(userName: string) {
    return this.http.get(this.baseUrl + 'isUserNameAvailable/' + userName)
    .subscribe(res => {
        console.log(res);
    });
}

}
