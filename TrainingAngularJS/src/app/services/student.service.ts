import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Student } from '../Models/student.model'

@Injectable()
export class StudentService {

  constructor(private http: HttpClient) { }

  private currentStudent: Student

  setCurrentStudent(student: Student) {
    this.currentStudent = student;
  }

  getCurrentStudent() {
    return this.currentStudent;
  }

  getStudents(){
    return this.http.get('http://localhost:52805/api/student')
  }

  getStudent(id){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',        
      })
    };

    return this.http.get('http://localhost:52805/api/student/' + id)
  }

  deleteStudent(id){
    return this.http.delete('http://localhost:52805/api/student/'+ id)
  }

  putStudent(student){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',        
      })
    };
    return this.http.put('http://localhost:52805/api/student', student, httpOptions)
  }

  postStudent(student){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',        
      })
    };

    return this.http.post('http://localhost:52805/api/student', student, httpOptions)

  }
}
