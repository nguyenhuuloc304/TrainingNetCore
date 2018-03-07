import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Router, ActivatedRoute, Params} from '@angular/router';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {


  constructor(private http: HttpClient, private activatedRoute: ActivatedRoute, private router: Router,private studentService: StudentService) { }


  public httpOptions: any;
  public id:string ='';
  public HoTen: string ='';


  ngOnInit(): void {
    console.log("start");
    this.HoTen = this.studentService.getCurrentStudent().hoTen;
    console.log(this.studentService.getCurrentStudent());
  }

  edit(){
    console.log("Init data");
    var student ={
      id: this.id,
      HoTen: this.HoTen
    }
    
    this.studentService.putStudent(student).subscribe(data => {
      this.router.navigateByUrl('');
    });
  }

}
