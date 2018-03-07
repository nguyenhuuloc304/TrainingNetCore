import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { StudentService } from './services/student.service';
import { AlertModule } from 'ngx-bootstrap';


import { AppComponent } from './app.component';
import { CreateStudentComponent } from './create-student/create-student.component';
import { StudentsComponent } from './students/students.component';
import { EditStudentComponent } from './edit-student/edit-student.component';
import { DeleteStudentComponent } from './delete-student/delete-student.component';

const routers: Routes = [
  { path: "", component: StudentsComponent, pathMatch: 'full' },
  { path: "CreateStudent", component: CreateStudentComponent },
  { path: "EditStudent", component: EditStudentComponent },
  // { path: "Toeic", component: ToeicList },
  // { path: "Remember/Play/:id", component: RememberWord }
];

@NgModule({
  declarations: [
    AppComponent,
    CreateStudentComponent,
    StudentsComponent,
    EditStudentComponent,
    DeleteStudentComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routers,
      {
          enableTracing: false
      }
    ),
    AlertModule.forRoot()
  ],
  providers: [StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
