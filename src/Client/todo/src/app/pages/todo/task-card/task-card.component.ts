import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ITask } from 'src/app/models/task.view-model';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent implements OnInit {
  @Input() task: ITask;
  @Output() onTaskDelete = new EventEmitter<ITask>();
  constructor(private taskService: TaskService) { }

  ngOnInit() {
  }

  delete() {
    this.taskService.delete(this.task.id).subscribe(_ => this.onTaskDelete.emit(this.task))
  }
}
