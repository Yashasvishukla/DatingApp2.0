import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { AlertifyService } from './alertify.service';

// const httpOptions = {
//   headers : new HttpHeaders({
//     'Authorization' : 'Bearer ' + localStorage.getItem('token')
//   })
// };

@Injectable({
  providedIn: 'root'
})


export class UserService {

  baseUrl = environment.apiUrl;
constructor(private http: HttpClient, private alertify: AlertifyService, private router: Router) { }

getUsers(): Observable<User[]>{
  return this.http.get<User[]>(this.baseUrl + 'users');
}

getUser(id): Observable<User>{
  return this.http.get<User>(this.baseUrl + 'users/' + id);
}

}
