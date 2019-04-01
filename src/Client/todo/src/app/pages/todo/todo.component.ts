import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { ITask } from 'src/app/models/task.view-model';
import { MatDialog } from '@angular/material';
import { AddTaskDialogComponent } from './add-task-dialog/add-task-dialog.component';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  toDoTasks: ITask[];
  inProgressTasks: ITask[];
  doneTasks: ITask[];
  constructor(private taskService: TaskService, public dialog: MatDialog) { }

  ngOnInit() {
    this.getTasks();
  }

  openAddTaskDialog() {
    const dialogRef = this.dialog.open(AddTaskDialogComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(isCompleted => {
      if (isCompleted) {
        this.getTasks();
      }
    });
  }

  getTasks() {
    this.taskService.get().subscribe(x => {
      this.toDoTasks = x.filter(x => x.statusId === 0);
      this.inProgressTasks = x.filter(x => x.statusId === 1);
      this.doneTasks = x.filter(x => x.statusId === 2);
    });
  }

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }
}
