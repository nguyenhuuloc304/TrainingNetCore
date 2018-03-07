import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.css']
})
export class CreateStudentComponent implements OnInit {

  constructor(private router: Router,private studentService: StudentService) { }

  public HoTen:string ='';
  public isDisabled;

  ngOnInit() {
    this.isDisabled = false;
  }

  create(){
    this.isDisabled = true;
    var student = {
      id: null,
      HoTen : this.HoTen
    };
    this.studentService.postStudent(student).subscribe(data => {
      this.router.navigateByUrl('');
    });
  }
}
