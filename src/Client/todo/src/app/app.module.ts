import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatButtonModule, MatCheckboxModule, MatDialogModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TodoComponent } from './pages/todo/todo.component';
import { AddTaskDialogComponent } from './pages/todo/add-task-dialog/add-task-dialog.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TaskTypeAsyncPipe } from 'src/pipes/Tasks/task-type-filter.pipe';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [
    AppComponent,
    AddTaskDialogComponent,
    TodoComponent,
    TaskTypeAsyncPipe
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    DragDropModule

  ],
  providers: [],
  entryComponents: [
    AddTaskDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
