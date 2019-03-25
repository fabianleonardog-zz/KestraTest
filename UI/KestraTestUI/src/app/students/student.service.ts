import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IStudent } from './student';
import { ISubject } from './subject';

@Injectable({
    providedIn: 'root'
})
export class StudentService {

    private studentApiUrl: string = 'https://localhost:44374/api/';
    private studentReportUrl = 'StudentResport'
    private subjectUrl = 'Subject';
    
    constructor(private http: HttpClient){}

    getStudents(studentName: string, gradeGreatherThan: number, subjectName: string): Observable<IStudent[]> {
        let params = new HttpParams()
        .set("studentName", (studentName) ? studentName : '')
        .set("gradeGreatherThan", (gradeGreatherThan) ? gradeGreatherThan.toString(): '')
        .set("subjectName", (subjectName) ? subjectName: '');

        return this.http.get<IStudent[]>(this.studentApiUrl + this.studentReportUrl, { params }).pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
            catchError(this.handleError)
          );
    }
      
    getSubjects(): Observable<ISubject[]>{
        return this.http.get<ISubject[]>(this.studentApiUrl + this.subjectUrl);
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
        // A client-side or network error occurred. Handle it accordingly.
        errorMessage = `An error occurred: ${err.error.message}`;
        } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong,
        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
}