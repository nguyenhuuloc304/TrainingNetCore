import { Component, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';

import 'rxjs/add/operator/map';
import { Student } from '../Models/student.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: any;  
  title = "HELL";

  constructor( private studentService: StudentService,private router: Router) { 

  }

  ngOnInit(): void {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    })
  }

  update() {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    })
  }

  delete(id){
    this.studentService.deleteStudent(id).subscribe(data => {
      this.update();
    });
  }

  edit(student: Student){
    this.studentService.setCurrentStudent(student);
    console.log(student);

    this.router.navigateByUrl('/EditStudent');
    console.log("end edit");
  }
}
