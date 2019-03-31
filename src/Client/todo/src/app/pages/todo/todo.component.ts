import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { ITask } from 'src/app/models/task.view-model';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material';
import { AddTaskDialogComponent } from './add-task-dialog/add-task-dialog.component';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  tasks: Observable<ITask[]>;
  constructor(private taskService:TaskService, public dialog: MatDialog) { }

  ngOnInit() {
    this.getTasks();
  }

  openAddTaskDialog(){
    const dialogRef = this.dialog.open(AddTaskDialogComponent, {
    width: '250px'
  });

  dialogRef.afterClosed().subscribe(isCompleted => {
    if (isCompleted) {
      this.getTasks();
    }
  });
}

  getTasks(){
    this.tasks = this.taskService.get();
  }

}
