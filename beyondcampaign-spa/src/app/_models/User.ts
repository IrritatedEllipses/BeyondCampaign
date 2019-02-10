export interface User {
    id: number;
    userName: string;
    email: string;
    dateCreated: Date;
    lastActive: Date;
    isGm: boolean;
    isPlayer: boolean;
}
