import { Component, OnInit } from '@angular/core';
import { IStudent } from './student';
import { StudentService } from './student.service';

@Component({
  selector: 'pm-students',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit{
  pageTitle: string = 'Student List';
  studentNameFilter: string;
  gradeGratherThan: number;
  subjectName: string;
  students: IStudent[];
  errorMessage: string;
  
  constructor (private studentService: StudentService) {

  }


  ngOnInit(): void{
      this.studentService.getStudents(null,null,null).subscribe(
        students => this.students = students,
        error => this.errorMessage = <any>error
      );
  }

  getStudents(): void {
    this.studentService.getStudents(this.studentNameFilter,this.gradeGratherThan,this.subjectName).subscribe(
      students => this.students = students,
      error => this.errorMessage = <any>error
    );
  }
}