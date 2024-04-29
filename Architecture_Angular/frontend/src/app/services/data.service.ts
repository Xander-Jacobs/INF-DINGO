import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, Subject } from 'rxjs';
import { Course } from '../shared/course';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  apiUrl = 'https://localhost:7049/api/'

  httpOptions ={
    headers: new HttpHeaders({
      ContentType: 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { 
  }

  GetCourses(): Observable<any>{
    return this.httpClient.get(`${this.apiUrl}Course/GetAllCourses`)
    .pipe(map(result => result))
  }

  GetCourse(courseId: number): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}Course/GetCourse/${courseId}`)
    .pipe(map(result=>result))
  }

  UpdateCourse(course:Course):Observable<any>{
    return this.httpClient.put(`${this.apiUrl}Course/UpdateCourse/${course.courseId}`, course)
    .pipe(map(result=>result))
  }

  DeleteCourse(courseId: number): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}Course/DeleteCourse/${courseId}`,{})
    .pipe(map(result=>result))
  }

  AddCourse(course:Course):Observable<any>{
    return this.httpClient.post(`${this.apiUrl}Course/AddCourse`,course)
    .pipe(map(result=>result))
  }


}


