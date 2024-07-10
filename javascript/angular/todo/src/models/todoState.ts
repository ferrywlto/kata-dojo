export class TodoState {
    id!: number;
    title: string = "";
    done: boolean = false;
    due: Date = new Date();
}