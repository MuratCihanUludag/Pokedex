import { createContext, useState } from "react";
const DataContext = createContext();
export const DataContextProvide = ({ children }) => {
  const [data, setData] = useState({});
  
  return <DataContext.Provider value={data}> {children} </DataContext.Provider>;
};
export default DataContextProvide;
