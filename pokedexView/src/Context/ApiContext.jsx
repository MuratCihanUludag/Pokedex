import { createContext } from "react";
const ApiContex = createContext();
export const ApiContexProvider = ({ children }) => {
  return <ApiContex.Provider> {children} </ApiContex.Provider>;
};
export default ApiContexProvider;
