import { Pipe, PipeTransform } from '@angular/core';
import { ITask } from 'src/app/models/task.view-model';

@Pipe({
  name: 'taskTypeAsyncPipe'
})
export class TaskTypeAsyncPipe implements PipeTransform {

  transform(tasks: ITask[], taskId: number) {
    if (tasks) {
      return tasks.filter(x => x.statusId === taskId);
    }
  }
}
